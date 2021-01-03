# Change Log
All notable changes to the "SSDT-Continuous-Deployment-Project-Template-Helpers" extension will be documented in this file.

Check [Keep a Changelog](http://keepachangelog.com/) for recommendations on how to structure this file.

## [Unreleased]

## [1.1.0] - 2021-01-04

### Changed

* #20. Change promoter. The context menu for sql files behaves diferently based on the file termination. Handling change promotions with:
    - user interface "Destination picker" for "\*.set" matching files 
    - automatic for "\*.all" files

### Added

* #20. Change promoter. Added basic UI for promotting changes. The UI is presented only for files that matches "\*.set.sql" pattern.
    - the subject to promotion must match "*.set.sql"
    - the subject to promotion must be a sql script
    - the subject to promotion must have the "Build Action" as "None"
    - the destination file must match "*.main.datapatch.sql"
    - the destination file must be in a folder of the same level as the subject
    - the destination file must be checked in the "Destination Picker" dialog box

## [1.0.1] - 2020-12-31

### Fixed

* #17. Change Promoter. Context menu is visible only for sql files. The visibility was deffered to vsct constraint
* #16. Change Promoter. The checking for existing reference was switched as case insensitive

## [1.0.0] - 2020-12-30

### Added

* published version to Marketplace
* complete implementation for Datapatch Wrapper
* complete implementation for Change Promoter
* demo project
* unit tests project

## [0.1.0] - 2020-12-24

### Added

* initial version
* basic extension implementation for Datapatch Wrapper
