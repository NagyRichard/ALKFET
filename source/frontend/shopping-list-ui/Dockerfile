# 1. build stage
FROM node:20-alpine AS build

WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .

RUN npm run build -- --configuration production

# 2. runtime stage
FROM nginx:alpine

COPY nginx.conf /etc/nginx/conf.d/default.conf

# Az Angular build output-ját másoljuk a nginx által kiszolgált HTML fájlokat tartalmazó könyvtárba
COPY --from=build /app/dist/shopping-list-ui/browser /usr/share/nginx/html 

EXPOSE 80