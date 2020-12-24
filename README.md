# SSDT-Continuous-Deployment-Project-Template-Helpers

This a Visual Studio extension that add some helpers to the [SSDT-Continuous-Deployment-Project-Template](https://github.com/RadoslavGatev/SSDT-Continuous-Deployment-Project-Template)

# A quick wrapper command for data patches

In order to capture changes into migration tables a datapatch should be applied through **sp_execute_cd_script**. Using the quick wrapper the user can create a datapatch as a plain script with DML statements (INSERT/UPDATE/DELETE) and transform it as parameter to **sp_execute_cd_script**

# A change promoter of data patches to sibling projects that shares the same schema

If the base schema is distributed to several independent databases, this tool will help promoting the datapatch to several sibling projects.
