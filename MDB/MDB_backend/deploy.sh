#!/bin/bash
if [ $1 -eq 0 ]
	then 
		echo "Invalid heroku username. Please provide it as arg"
		exit 1
fi

echo "---------------------------- Building dotnet project"
echo
cd ../
dotnet publish -c Release

echo
echo
echo "---------------------------- Logging into heroku with username: $1"
echo
cd MDB_backend/bin/Release/netcoreapp3.1/publish

docker login --username=$1 --password=$(heroku auth:token) registry.heroku.com
heroku container:login

echo
echo
echo "---------------------------- Building with app docker"
echo
cp "C:\\Stuff\\_UNI_\\4 Kursas\\1 Semestras\\T120B165 Saityno taikomųjų programų projektavimas\\MDB\\MDB\\MDB_backend\\Dockerfile" "C:\\Stuff\\_UNI_\\4 Kursas\\1 Semestras\\T120B165 Saityno taikomųjų programų projektavimas\\MDB\\MDB\\MDB_backend\\bin\\Release\\netcoreapp3.1\\publish\\Dockerfile"
docker build -t mbd-backend "C:\\Stuff\\_UNI_\\4 Kursas\\1 Semestras\\T120B165 Saityno taikomųjų programų projektavimas\\MDB\\MDB\\MDB_backend\\bin\\Release\\netcoreapp3.1\\publish"

echo
echo
echo "---------------------------- Adding heroku tag to app"
echo
docker tag mbd-backend registry.heroku.com/mbd-backend/web

echo
echo
echo "---------------------------- Pushing to heroku"
echo
docker push registry.heroku.com/mbd-backend/web

echo
echo
echo "---------------------------- Launching on heroku"
echo
heroku container:release web --app mbd-backend

while true; do
    read -p "Do you wish to see the app logs from heroku? [y/n] " yn
    case $yn in
        [Yy]* ) 
			heroku logs --tail --app mbd-backend; 
			break;;
        [Nn]* ) 
			exit;;
        * ) 
		echo "Please answer yes or no. [y/n]";;
    esac
done
