FROM node:22-alpine AS build
WORKDIR /app
COPY ../../.. .
RUN npm install
RUN npm run build -w frontend/apps/admin

FROM node:22-alpine
WORKDIR /app
COPY --from=build /app/frontend/apps/admin/dist ./dist
RUN npm install -g serve
EXPOSE 4173
CMD ["serve", "-s", "dist", "-l", "4173"]
