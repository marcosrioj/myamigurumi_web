FROM node:22-alpine AS build
WORKDIR /app
COPY . .
ENV NPM_CONFIG_FUND=false NPM_CONFIG_AUDIT=false
RUN npm install --workspaces --include-workspace-root --registry=https://registry.npmjs.org/
RUN npm run build -w frontend/apps/storefront

FROM node:22-alpine
WORKDIR /app
COPY --from=build /app/frontend/apps/storefront/dist ./dist
RUN npm install -g serve
EXPOSE 4173
CMD ["serve", "-s", "dist", "-l", "4173"]
