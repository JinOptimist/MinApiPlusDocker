
1) Create MinApi .net project
2) Create a Dockerfile
3) Build you image => docker build . --rm -t [image name example: "npc_api/server:dev"]
4) Create a container base on image => docker run -p 5000:5000 [imageID or name. Example: "npc_api/server:dev"] --host=0.0.0.0
docker run -p 8085:5000 npc_api/server