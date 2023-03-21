FROM node:18-alpine3.16 as build
WORKDIR /usr/src/app

RUN npm install -g @angular/cli@15.0.4

COPY package*.json .

COPY . .
RUN npm ci
RUN ng build

FROM nginx as runtime

RUN rm /etc/nginx/nginx.conf
COPY nginx.conf /etc/nginx/

COPY --from=build /usr/src/app/dist/car-park-ui /usr/share/nginx/html
EXPOSE 80