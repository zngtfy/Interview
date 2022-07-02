
# 6. Migration
Set as Startup Project: Matcha.Home
Tools -> Nuget Package Manager -> Open Package Manager Console
Default Project: Matcha.Home
Run command below:
Add-Migration InitData
Update-Database InitData

# 7. Create sync DB & update in appsettings.Development.json
DROP DATABASE coffeeshop;
CREATE DATABASE coffeeshop;
