#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0

RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
    && rm -rf /var/lib/apt/lists/* \
    && apt-get clean

RUN mkdir /app
WORKDIR /app

COPY . /app

EXPOSE 5000
CMD dotnet run --project Coderland.Api --no-launch-profile