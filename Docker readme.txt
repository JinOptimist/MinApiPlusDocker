Create Docker Container
1) Create MinApi .net project
2) Create a Dockerfile

3) Build you image => docker build . --rm -t [image name example: "npc_api/server:dev"]
	docker build . --rm -t npc_api/server:dev
or
	docker build . --rm -t npc_api/server:latest

4) Create a container base on image
	docker run -e ASPNETCORE_URLS=http://+:8001 -p 8081:8001 npc_api/server

5) Open http://localhost:8081
If you can't ping localhost:8081 open port 8081

FINISTH.
Graz. You have full functional one docker container



Creating connection between containers
1) Create a network
docker network create --driver nat rpg-network

2) Connect existed container to network
docker network connect rpg-network rpg
docker network connect rpg-network npc
docker network connect rpg-network rabbitmq


usefull command
	docker images
	docker ps -a
	docker network ls
	docker network inspect rpg-network