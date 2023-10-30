# can be the problem
# no matching manifest for windows/amd64 10.0.19045 in the manifest list entries
# Solution here 
# https://stackoverflow.com/questions/48066994/docker-no-matching-manifest-for-windows-amd64-in-the-manifest-list-entries
docker pull rabbitmq
docker pull rabbitmq:3.10-management
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 --network rpg-network rabbitmq:3.10-management
