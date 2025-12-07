# Runtime base with .NET 10 installed via dotnet-install to avoid registry tag issues
FROM debian:12-slim AS runtime
ARG DOTNET_CHANNEL=10.0
ENV DOTNET_ROOT=/usr/share/dotnet
ENV PATH="${DOTNET_ROOT}:${PATH}"
RUN apt-get update && apt-get install -y --no-install-recommends ca-certificates curl \
 && apt-get install -y --no-install-recommends libicu-dev \
 && rm -rf /var/lib/apt/lists/* \
 && curl -sSL https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh \
 && chmod +x dotnet-install.sh \
 && ./dotnet-install.sh --channel ${DOTNET_CHANNEL} --quality ga --install-dir ${DOTNET_ROOT} --runtime aspnetcore
WORKDIR /app
EXPOSE 8080

# Build stage with .NET 10 SDK from dotnet-install
FROM debian:12-slim AS build
ARG DOTNET_CHANNEL=10.0
ENV DOTNET_ROOT=/usr/share/dotnet
ENV PATH="${DOTNET_ROOT}:${PATH}"
RUN apt-get update && apt-get install -y --no-install-recommends ca-certificates curl \
 && apt-get install -y --no-install-recommends libicu-dev \
 && rm -rf /var/lib/apt/lists/* \
 && curl -sSL https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh \
 && chmod +x dotnet-install.sh \
 && ./dotnet-install.sh --channel ${DOTNET_CHANNEL} --quality ga --install-dir ${DOTNET_ROOT}
WORKDIR /src
COPY . .
RUN dotnet restore Api/Identity.Api.csproj
RUN dotnet publish Api/Identity.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM runtime AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]
