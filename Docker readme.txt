
1) Create MinApi .net project
2) Create a Dockerfile

3) Build you image => docker build . --rm -t [image name example: "npc_api/server:dev"]
	docker build . --rm -t npc_api/server:dev
or
	docker build . --rm -t npc_api/server:latest

4) Create a container base on image
	docker run -e ASPNETCORE_URLS=http://+:8001 -p 8081:8001 npc_api/server

5) If you can't ping localhost:8081 open port 8081



usefull command
	docker images
	docker ps -a