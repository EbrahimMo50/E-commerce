# E-commerece v1.0
 a microservice prototype 

current state of the app
 
this hot mess of application requires alot of work to be valid corner stone at least

pathing of the services is messed up since the set up from the beggining was faulty

the auth system is working fine with roles, further expandable services are allowed to utillize the system lurking in the users service

the apigateway may require some adjustment to the ports based on the deployment

k8s and docker failed because current system doesnt now allow port binding (no connection to sql/ nodeports binding)

developing the application on forks requires no further commands all the migrations are automated with seeding

note that all services utillize http 

async messaging between serivices is not implemented requires a message bus and logic implemnation, system running on sync consider running async for further decoupling

system designed following the repository design pattern each service has its repo with the interface
