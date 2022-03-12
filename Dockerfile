### Build and Test the App
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

### copy the source and tests
COPY . /src

WORKDIR /src

# build the app
RUN dotnet publish -c Release -o /app

###########################################################


### Build the runtime container
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS release

### if port is changed, also update value in Config
EXPOSE 8080
WORKDIR /app

### create a user
### dotnet needs a home directory
RUN addgroup -S imdb && \
    adduser -S imdb -G imdb && \
    mkdir -p /home/imdb && \
    chown -R imdb:imdb /home/imdb

### run as imdb user
USER imdb

### copy the app
COPY --from=build /app .

ENTRYPOINT [ "dotnet",  "imdb.dll" ]
