#FROM node:18 AS build
#WORKDIR /app
#COPY package*.json ./
#RUN npm install -g @angular/cli
##RUN npm install --legacy-peer-deps
#RUN npm install
#COPY . .
#RUN ng build --configuration production
#FROM nginx:alpine
#COPY nginx.conf /etc/nginx/nginx.conf
##RUN rm /usr/share/nginx/html/index.html
#COPY --from=build /app/dist/coffee-shop/browser /usr/share/nginx/html
#COPY nginx.conf /etc/nginx/conf.d/default.conf
#

FROM node:18 AS build
WORKDIR /app
COPY package*.json ./
RUN npm install -g @angular/cli
RUN npm install
COPY . .
RUN ng build --configuration production
FROM node:18 AS debug
WORKDIR /app
COPY package*.json ./
RUN npm install -g @angular/cli
RUN npm install
COPY --from=build /app/dist /app/dist
EXPOSE 4200
CMD ["ng", "serve", "--host", "0.0.0.0", "--port", "4200", "--disable-host-check"]
