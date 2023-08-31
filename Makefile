################## Variables ##################
MIGRATION_NAME := $(shell date +"%Y%m%d%H%M%S")
API_CSPROJ = src/API/API.csproj
INFRA_CSPROJ = src/Infrastructure/Infrastructure.csproj
MIGRATION_PATH = Persistance/EFCore/Migrations
DB_CONTEXT := MarketingDbContext
include .env

################## Migration ##################
migration-add:
	dotnet ef migrations add $(MIGRATION_NAME) --startup-project ${API_CSPROJ} --project ${INFRA_CSPROJ} --output-dir ${MIGRATION_PATH} --context ${DB_CONTEXT}
migration-up:
	dotnet ef database update --startup-project ${API_CSPROJ} --project ${INFRA_CSPROJ} --context ${DB_CONTEXT}
migration-down:
	dotnet ef database update $(MIGRATION_NAME) --startup-project ${API_CSPROJ} --project ${INFRA_CSPROJ} --context ${DB_CONTEXT}

# migration:
# 	@make migration-add
# 	@make migration-update

################## Installation ##################
install:
ifeq ($(findstring $(APP_ENV),Development Local),)
	docker compose --profile $(APP_ENV) -f docker-compose.yaml -f docker-compose-prod.yaml up -d
else
	LOCAL_CLICKHOUSE_HTTP_PORT=$(HOST_CLICKHOUSE_HTTP_PORT) LOCAL_CLICKHOUSE_NATIVE_PORT=$(HOST_CLICKHOUSE_NATIVE_PORT) LOCAL_CLICKHOUSE_TCP_PORT=$(HOST_CLICKHOUSE_TCP_PORT) LOCAL_CLICKHOUSE_GRPC_PORT=$(HOST_CLICKHOUSE_GRPC_PORT) LOCAL_RABBIT_PORT=$(HOST_RABBIT_PORT) LOCAL_DB_PORT=$(DB_PORT) LOCAL_REDIS_PORT=$(REDIS_PORT) docker compose --profile $(APP_ENV) -f docker-compose.yaml -f docker-compose-stage.yaml up -d
endif
install-with-gui:
ifeq ($(findstring $(APP_ENV),Development Local),)
	docker compose --profile $(APP_ENV) --profile phpmyadmin --profile redis-commander -f docker-compose.yaml -f docker-compose-prod.yaml up -d
else
	LOCAL_CLICKHOUSE_HTTP_PORT=$(HOST_CLICKHOUSE_HTTP_PORT) LOCAL_CLICKHOUSE_NATIVE_PORT=$(HOST_CLICKHOUSE_NATIVE_PORT) LOCAL_CLICKHOUSE_TCP_PORT=$(HOST_CLICKHOUSE_TCP_PORT) LOCAL_CLICKHOUSE_GRPC_PORT=$(HOST_CLICKHOUSE_GRPC_PORT) LOCAL_RABBIT_PORT=$(HOST_RABBIT_PORT) LOCAL_RABBIT_MANAGEMENT=$(HOST_RABBIT_MANAGEMENT) LOCAL_DB_PORT=$(DB_PORT) LOCAL_REDIS_PORT=$(REDIS_PORT) docker compose --profile $(APP_ENV) --profile phpmyadmin --profile redis-commander -f docker-compose.yaml -f docker-compose-stage.yaml up -d
endif

################## phony ##################
.PHONY: migration-add migration-up migration-down install install-with-gui