-- this script will cleanup/recreate random Checkin Areas/Groups

-- Set this to True to have checkin groups with Parent Groups. (this is not common)
declare @addParentGroups BIT = 0;

-- Set these values to create the needed environment
declare
      @maxCheckinTypes INT = 3
    , @maxRandomNumberAreasPerCheckinType INT = 10
	, @maxRandomNumberOfGroupsPerArea INT = 20
	, @roomLocationsToCreate INT = 20
	, @devicesToCreate INT = 50
	, @addToTestSchedules BIT = 1

DECLARE 
      @showInNavigation BIT = @addParentGroups 
    , @parentGroupId INT = NULL
	, @campusId INT = NULL
	, @groupName NVARCHAR(100)
	, @groupDescription NVARCHAR(max)
	, @groupGuid NVARCHAR(max)
	, @checkinTypeCounter INT = 0
	, @areaCounter INT = 0
	, @groupCounter INT = 0
	, @groupTypePurposeValueIdCheckinTemplate INT = (SELECT Id FROM DefinedValue WHERE Guid = '4A406CB0-495B-4795-B788-52BDFDE00B01')
	, @groupTypeIdGeneral INT = (SELECT Id FROM GroupType WHERE [Guid] = '8400497B-C52F-40AE-A529-3FCCB9587101')
	, @groupTypeIdCheckinType INT
	, @groupTypeIdCheckinArea INT
	, @groupTypeIdCheckinSubArea INT
	, @mainParentCheckinGroupId INT
	, @checkinTypeParentCheckinGroupId INT
	, @checkinTypeParentCheckinAreaGroupId INT

	, @CampusDefinedValueId INT = (
		SELECT TOP 1 dv.[Id]
		FROM DefinedType dt
		JOIN DefinedValue dv ON dt.Id = dv.DefinedTypeId
		WHERE dt.[Guid] = '3285DCEF-FAA4-43B9-9338-983F4A384ABA'
			AND dv.[Value] = 'Campus')
			
	, @RoomDefinedValueId INT = (
		SELECT TOP 1 dv.[Id]
		FROM DefinedType dt
		JOIN DefinedValue dv ON dt.Id = dv.DefinedTypeId
		WHERE dt.[Guid] = '3285DCEF-FAA4-43B9-9338-983F4A384ABA'
			AND dv.[Value] = 'Room')

	, @CheckinKioskDeviceTypeId INT = (
			SELECT TOP 1 dv.[Id]
			FROM [DefinedType] dt
			JOIN [DefinedValue] dv ON dt.[Id] = dv.[DefinedTypeId]
			WHERE dt.[Guid] = '0368B637-327A-4F5E-80C2-832079E482EE'
				AND [Value] = 'Check-in Kiosk')

BEGIN
	DELETE FROM [Group]
	WHERE GroupTypeId IN (SELECT Id FROM GroupType WHERE Name LIKE 'Checkin Random %' )
		OR Name LIKE 'Checkin Random Type Group%'
		OR Name LIKE 'Checkin Random Area Group%'

	UPDATE [Group]
	SET ParentGroupId = NULL
	WHERE ParentGroupId IN (SELECT Id FROM [Group] WHERE Name LIKE 'Checkin Random Groups')

	DELETE FROM [Group]	WHERE Name LIKE 'Checkin Random Groups'

	DELETE FROM [GroupTypeAssociation]
	WHERE [GroupTypeId] IN (
			SELECT Id
			FROM GroupType
			WHERE Name LIKE 'Checkin Random %'
			)
		OR [ChildGroupTypeId] IN (
			SELECT Id
			FROM GroupType
			WHERE Name LIKE 'Checkin Random %'
			);

	DELETE FROM [GroupType] WHERE name LIKE 'Checkin Random %'

	DELETE FROM [Group] WHERE Name LIKE 'Checkin Random Group %'

	DELETE FROM [Location] WHERE [Name] LIKE 'Checkin Random Room%'

	DELETE FROM [Device] WHERE [Name] LIKE 'Checkin Random Kiosk%'

	IF (@addParentGroups = 1)
	BEGIN
		INSERT INTO [dbo].[Group] (
			[IsSystem]
			,[ParentGroupId]
			,[GroupTypeId]
			,[CampusId]
			,[Name]
			,[Description]
			,[IsSecurityRole]
			,[IsActive]
			,[Order]
			,[CreatedDateTime]
			,[Guid]
			)
		VALUES (
			0
			,NULL
			,@groupTypeIdGeneral
			,@campusId
			,'Checkin Random Groups'
			,''
			,0
			,1
			,0
			,SYSDATETIME()
			,newid()
			);

		SELECT @mainParentCheckinGroupId = @@IDENTITY;
	END

	IF ( @roomLocationsToCreate > 0 )
	BEGIN
		
		DECLARE @roomLocationsIncrement INT = 0;
		WHILE @roomLocationsIncrement <= @roomLocationsToCreate
		BEGIN
			DECLARE @ParentLocationId INT = (SELECT TOP 1 [Id] FROM [Location] where LocationTypeValueId = @CampusDefinedValueId and IsActive = 1 ORDER BY NEWID())

			SET @roomLocationsIncrement = @roomLocationsIncrement + 1
			INSERT INTO [Location](ParentLocationId, [Name], IsActive, LocationTypeValueId, [Guid])
			VALUES(@ParentLocationId, 'Checkin Random Room ' + convert(varchar, @roomLocationsIncrement), 1, @RoomDefinedValueId, newid())
		END
	END

	WHILE @checkinTypeCounter < @maxCheckinTypes
	BEGIN
		INSERT INTO [dbo].[GroupType] (
			[IsSystem]
			,[Name]
			,[GroupTypePurposeValueId]
			,[GroupTerm]
			,[GroupMemberTerm]
			,[AllowMultipleLocations]
			,[ShowInGroupList]
			,[ShowInNavigation]
			,[IconCssClass]
			,[TakesAttendance]
			,[AttendanceRule]
			,[AttendancePrintTo]
			,[Order]
			,[LocationSelectionMode]
			,[CreatedDateTime]
			,[Guid]
			)
		VALUES (
			0 -- [IsSystem]
			,CONCAT (
				'Checkin Random Type '
				,@checkinTypeCounter
				) -- [Name]
			,@groupTypePurposeValueIdCheckinTemplate -- [GroupTypePurposeValueId]
			,'Group' -- [GroupTerm]
			,'Member' -- [GroupMemberTerm] 
			,0 -- [AllowMultipleLocations]
			,@showInNavigation -- [ShowInGroupList]
			,@showInNavigation -- [ShowInNavigation]
			,'fa fa-rocket' -- [IconCssClass]
			,1 -- [TakesAttendance]
			,0 -- [AttendanceRule]
			,0 -- [AttendancePrintTo]
			,0 -- [Order]
			,0 -- [LocationSelectionMode]
			,SYSDATETIME() -- [CreatedDateTime] 
			,newid() -- [Guid]
			)

		SELECT @groupTypeIdCheckinType = @@IDENTITY

		SELECT @areaCounter = 0

		IF (@addParentGroups = 1)
		BEGIN
			INSERT INTO [dbo].[Group] (
				[IsSystem]
				,[ParentGroupId]
				,[GroupTypeId]
				,[CampusId]
				,[Name]
				,[Description]
				,[IsSecurityRole]
				,[IsActive]
				,[Order]
				,[CreatedDateTime]
				,[Guid]
				)
			VALUES (
				0
				,@mainParentCheckinGroupId
				,@groupTypeIdGeneral
				,@campusId
				,CONCAT (
					'Checkin Random Type Group '
					,@checkinTypeCounter
					)
				,@groupDescription
				,0
				,1
				,0
				,SYSDATETIME()
				,newid()
				);

			SELECT @checkinTypeParentCheckinGroupId = @@IDENTITY;
		END

        declare @maxAreasPerCheckinType int = rand()*@maxRandomNumberAreasPerCheckinType

		-- Checkin areas 
		WHILE @areaCounter < @maxAreasPerCheckinType
		BEGIN
			INSERT INTO [dbo].[GroupType] (
				[IsSystem]
				,[Name]
				,[GroupTypePurposeValueId]
				,[GroupTerm]
				,[GroupMemberTerm]
				,[AllowMultipleLocations]
				,[ShowInGroupList]
				,[ShowInNavigation]
				,[IconCssClass]
				,[TakesAttendance]
				,[AttendanceRule]
				,[AttendancePrintTo]
				,[Order]
				,[LocationSelectionMode]
				,[CreatedDateTime]
				,[Guid]
				)
			VALUES (
				0 -- [IsSystem]
				,CONCAT (
					'Checkin Random Area '
					,@checkinTypeCounter
					,'_'
					,@areaCounter
					) -- [Name]
				,NULL -- @groupTypePurposeValueIdCheckinFilter -- [GroupTypePurposeValueId]
				,'Group' -- [GroupTerm]
				,'Member' -- [GroupMemberTerm] 
				,0 -- [AllowMultipleLocations]
				,@showInNavigation -- [ShowInGroupList]
				,@showInNavigation -- [ShowInNavigation]
				,'fa fa-star' -- [IconCssClass]
				,1 -- [TakesAttendance]
				,0 -- [AttendanceRule]
				,0 -- [AttendancePrintTo]
				,0 -- [Order]
				,0 -- [LocationSelectionMode]
				,SYSDATETIME() -- [CreatedDateTime] 
				,newid() -- [Guid]
				)

			SELECT @groupTypeIdCheckinArea = @@IDENTITY

			INSERT INTO [dbo].[GroupTypeAssociation] (
				GroupTypeId
				,ChildGroupTypeId
				)
			VALUES (
				@groupTypeIdCheckinType
				,@groupTypeIdCheckinArea
				)

			IF (@addParentGroups = 1)
			BEGIN
				INSERT INTO [dbo].[Group] (
					[IsSystem]
					,[ParentGroupId]
					,[GroupTypeId]
					,[CampusId]
					,[Name]
					,[Description]
					,[IsSecurityRole]
					,[IsActive]
					,[Order]
					,[CreatedDateTime]
					,[Guid]
					)
				VALUES (
					0
					,@checkinTypeParentCheckinGroupId
					,@groupTypeIdGeneral
					,@campusId
					,CONCAT (
						'Checkin Random Area Group '
						,@areaCounter
						,'_'
						,@checkinTypeCounter
						)
					,@groupDescription
					,0
					,1
					,0
					,SYSDATETIME()
					,newid()
					);

				SELECT @checkinTypeParentCheckinAreaGroupId = @@IDENTITY;
			END

			SELECT @groupCounter = 0

			DECLARE @maxGroupsPerArea INT = rand() * @maxRandomNumberOfGroupsPerArea;

			-- Checkin groups
			WHILE @groupCounter < @maxGroupsPerArea
			BEGIN
				SELECT @groupGuid = NEWID();

				SELECT @groupName = CONCAT (
						'Checkin Random Group '
						,@areaCounter
						,'_'
						,@checkinTypeCounter
                        ,'_'
                        ,@groupCounter
						)

				INSERT INTO [dbo].[Group] (
					[IsSystem]
					,[ParentGroupId]
					,[GroupTypeId]
					,[CampusId]
					,[Name]
					,[Description]
					,[IsSecurityRole]
					,[IsActive]
					,[Order]
					,[CreatedDateTime]
					,[Guid]
					)
				VALUES (
					0
					,@checkinTypeParentCheckinAreaGroupId
					,@groupTypeIdCheckinArea
					,@campusId
					,@groupName
					,@groupDescription
					,0
					,1
					,0
					,SYSDATETIME()
					,@groupGuid
					);

				DECLARE @groupGroupId INT = @@IDENTITY

				INSERT INTO [dbo].[GroupLocation] (
					[GroupId]
					,[LocationId]
					,[IsMailingLocation]
					,[IsMappedLocation]
					,[Guid]
					,[Order]
					)
				SELECT @groupGroupId
					,l.Id
					,0
					,0
					,newid()
					,0
				FROM [Location] l
				WHERE LocationTypeValueId = (
						SELECT Id
						FROM DefinedValue
						WHERE [Guid] = '107C6DA1-266D-4E1C-A443-1CD37064601D'
						)

				SET @groupCounter += 1;

				IF (@groupCounter % 50 = 0)
				BEGIN
					PRINT @groupCounter
					PRINT @areaCounter
					PRINT @checkinTypeCounter
					PRINT '----'
				END
			END;

			SET @areaCounter += 1;
		END;

		SET @checkinTypeCounter += 1;
	END;

	IF (@addToTestSchedules = 1 )
	BEGIN
		DECLARE @scheduleId INT
		DECLARE scheduleCursor CURSOR FOR SELECT [Id] FROM [Schedule] WHERE [Guid] in ('A5C81078-EB8C-46AA-BB91-1E2BA8BA76AE', 'C8B7BEB4-54E2-4473-822F-F5D0F8CE19D7')

		OPEN scheduleCursor
		FETCH NEXT FROM scheduleCursor INTO @scheduleId

		WHILE @@FETCH_STATUS = 0
		BEGIN
			INSERT INTO GroupLocationSchedule(GroupLocationId, ScheduleId)
			SELECT id, @scheduleId
			FROM [GroupLocation] gl
			WHERE GroupId in (SELECT [Id] FROM [Group] WHERE NAME LIKE 'Checkin Random Group%')

			FETCH NEXT FROM scheduleCursor INTO @scheduleId
		END
		
		CLOSE scheduleCursor
		DEALLOCATE scheduleCursor
	END

	IF (@devicesToCreate > 0)
	BEGIN
		DECLARE @devicesIncrement INT = 0;
		WHILE @devicesIncrement <= @devicesToCreate
		BEGIN
			SET @devicesIncrement = @devicesIncrement + 1
			
			DECLARE @DeviceLocatinId INT = (SELECT TOP 1 [Id] FROM [Location] where LocationTypeValueId = @CampusDefinedValueId and IsActive = 1)
			INSERT INTO [Device]([Name], DeviceTypeValueId, LocationId, PrintFrom, PrintToOverride, [Guid], IsActive, HasCamera, KioskType)
			Values('Checkin Random Kiosk ' + convert(varchar, @devicesIncrement), @CheckinKioskDeviceTypeId, @DeviceLocatinId, 0, 0, NEWID(), 1, 0, 0)

			DECLARE @DeviceId INT = @@Identity

			INSERT INTO DeviceLocation(DeviceId, LocationId)
			SELECT @DeviceId, [Id]
			FROM [Location]
			WHERE [Id] IN (SELECT [Id] FROM [Location] WHERE LocationTypeValueId = @CampusDefinedValueId and IsActive = 1)
		END
	END
END