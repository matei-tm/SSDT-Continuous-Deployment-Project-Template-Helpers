# SSDT-Continuous-Deployment-Project-Template-Helpers

[![GitHub release](https://img.shields.io/github/release-pre/matei-tm/SSDT-Continuous-Deployment-Project-Template-Helpers.svg)](https://github.com/matei-tm/SSDT-Continuous-Deployment-Project-Template-Helpers/releases/)
[![Build status](https://ci.appveyor.com/api/projects/status/69dmplbwcjswi7gs/branch/main?svg=true)](https://ci.appveyor.com/project/matei-tm/ssdt-continuous-deployment-project-template-helper/branch/main)
![GitHub](https://img.shields.io/github/license/matei-tm/SSDT-Continuous-Deployment-Project-Template-Helpers)


This a Visual Studio extension that add some helpers to the [SSDT-Continuous-Deployment-Project-Template](https://github.com/RadoslavGatev/SSDT-Continuous-Deployment-Project-Template)

# A quick wrapper command for data patches

In order to capture changes into migration tables a datapatch should be applied through **sp_execute_cd_script**. Using the quick wrapper the user can create a datapatch as a plain script with DML statements (INSERT/UPDATE/DELETE) and transform it as parameter to **sp_execute_cd_script**

![datapatch-wrapper](docs/media/datapatchwrapper-howto.gif)

# A change promoter of data patches to sibling projects that shares the same schema

If the base schema is distributed to several independent databases, this tool will help promoting the datapatch to several sibling projects.
It works with a naming convention. All the files that are matching the pattern "*.all.sql" can be promoted to all sibling files matching "*.main.datapatch.sql"

![changepromoter-howto](docs/media/changepromoter-howto.gif)

## Constraints for a valid promotion

- the subject to promotion must match "*.all.sql"
- the subject to promotion must be a sql script
- the subject to promotion must have the "Build Action" as "None"
- the destination file must match "*.main.datapatch.sql"
- the destination file must be in a folder of the same level as the subject

![changepromo-hier](docs/media/changepromo-hier.png)