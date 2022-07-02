# 1. Basic setup
# 1.1. Setup git
sudo yum install git -y
git config --global user.name "Deployer"
git config --global user.email "toan@immexgroup.com"
git config --global credential.helper store

# 1.2. Get source code
# rm -rf /home/project-dotnet/liverpool
git clone --single-branch -b dev https://gitlab.immexgroup.com/default/liverpool.git /home/project-dotnet/liverpool

# 1.3. Store user & password
cd /home/project-dotnet/liverpool
git config --global credential.helper store
git pull

# 1.4. Get media file
# rm -rf /home/project-assets/liverpool
git clone --single-branch -b dev https://gitlab.immexgroup.com/media/liverpool.git /home/project-assets/liverpool

# 2. Build image
cd /home/project-dotnet/liverpool
git pull
docker build -t liverpool-ms-aps -f ms-aps.Dockerfile .
docker build -t liverpool-ms-api -f ms-api.Dockerfile .

# 3. Run (not use, use Configuration\Docker\docker-compose\matcha)
# docker stop liverpool-ms && docker rm liverpool-ms
docker run --name liverpool-ms --restart always -p 8001:80 -d liverpool-ms

cd /home/project-dotnet/liverpool
git pull
docker-compose up -d

# 4. Install netstat
ip a
sudo yum install net-tools -y

# 5. Check port (run with sudo to see more details)
netstat -lnp --tcp
ss -tulpn

# 6. Migration
Set as Startup Project: Matcha.Home
Tools -> Nuget Package Manager -> Open Package Manager Console
Default Project: Matcha.Home
Run command below:
Add-Migration InitData
Update-Database InitData

# 7. Create sync DB & update in appsettings.Development.json
DROP DATABASE `local_liverpool-home-sync`;
CREATE DATABASE `local_liverpool-home-sync` CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_general_ci';
