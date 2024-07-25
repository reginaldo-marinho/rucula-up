FROM node:slim AS build
WORKDIR /app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:stable-alpine3.19-slim
WORKDIR /etc/nginx/conf.d/
COPY rucula.conf .

WORKDIR /var/www/html/rucula-up/
COPY --from=build /app/dist/rucula-up/ .

EXPOSE 9000