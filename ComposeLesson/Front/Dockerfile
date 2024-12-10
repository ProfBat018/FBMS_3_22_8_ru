FROM node:18-alpine
WORKDIR /app

COPY ./client/package*.json ./
RUN npm install

COPY ./client ./
RUN npm run build
WORKDIR /app/build

FROM nginx:1.23-alpine
COPY --from=0 /app/build /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]