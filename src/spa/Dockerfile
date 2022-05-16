FROM node:current-alpine AS build
WORKDIR /usr/src/ng-app
COPY ["package*.json", "./"]
RUN npm install
COPY ["/", "."]
RUN npm run build

FROM nginx:stable-alpine
COPY --from=build /usr/src/ng-app/dist/psdtweesite /usr/share/nginx/html
COPY nginx-custom.conf /etc/nginx/conf.d/default.conf
