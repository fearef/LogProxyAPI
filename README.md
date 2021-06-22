# LogProxyAPI

Instructions how to build and run:

1. Pull the docker image from GitHub
docker pull ghcr.io/fearef/logproxyapi:master

2. Run the docker image in the container
3. using docker terminal send following commands to test the endpoints

For POST Endpoint:
curl -XPOST -H 'ApiKey: 4528482B4B625065' -H "Content-type: application/json" -d '{ "title": "Test exception", "Text": "Exception is a test exception"  }' 'http://localhost:80/api'

For GET Endpoint:
curl -XGET -H 'ApiKey: 4528482B4B625065' 'http://localhost:80/api'
