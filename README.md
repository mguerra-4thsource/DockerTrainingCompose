# DockerTrainingCompose

Commands:

cls
docker --version
docker ps
docker images
docker pull mysql
docker volume create dblocal
docker run --name dblocal -e MYSQL_RANDOM_ROOT_PASSWORD=yes -e MYSQL_DATABASE=Tickets -e MYSQL_USER=admin -e MYSQL_PASSWORD=test -v db-test:/var/lib/mysql -p 3018:3306 -d mysql
dotnet ef migrations add Initial
docker build -f "C:\Users\miguel.guerra\source\repos\docker_compose_training-master\Session7\Session7\Dockerfile" --force-rm -t miguel_guerra_dockers_img "C:\Users\miguel.guerra\source\repos\docker_compose_training-master\Session7\Session7"
docker run --name miguel_guerra_dockers_app -p 8086:80 -e "ConnectionStrings:TicketDB"="Server=dblocal;Port=3306;Database=Tickets; Uid=admin; Pwd=test" --link dblocal -it miguel_guerra_dockers_img
docker build -f "C:\Users\miguel.guerra\source\repos\docker_compose_training-master\Session7\Session7\Dockerfile" --force-rm -t miguel_guerra_dockers_img "C:\Users\miguel.guerra\source\repos\docker_compose_training-master\Session7\Session7"
docker images
docker tag 8a18ab07122f dockertraining2020/docker_training_compose_miguel_guerra_yaml:dockerTest
docker push dockertraining2020/docker_training_compose_miguel_guerra_yaml:tagname

Github link
https://github.com/mguerra-4thsource/DockerTrainingCompose

Docker hub Link
https://hub.docker.com/repository/docker/dockertraining2020/docker_training_compose_miguel_guerra_yaml

YAML CONFIG FILE

version: '3.4'

services:
  mydb:
     image: mysql
     container_name: "database_container"
     environment:
         MYSQL_DATABASE: "Tickets"
         MYSQL_USER: "admin"
         MYSQL_PASSWORD: "test"
         MYSQL_ROOT_PASSWORD: "root"
     ports:
     - "3018:3306"
     volumes:
     - mydbvol:/var/lib/mysql
  docker_training_miguel_guerra:
     image: ${DOCKER_REGISTRY-}dockertrainingmiguelguerra
     container_name: "api_container"
     build:
         context: .
         dockerfile: Session7/Dockerfile
     ports: 
     - "8091:80"
     environment: 
         "ConnectionStrings:TicketDB" : "Server=database_container;Port=3306;Database=Tickets;Uid=admin;Pwd=test"
     depends_on:
     - mydb
volumes:
     mydbvol:
