# Stage 1: Build Angular app
FROM node:18.20-alpine as builder

WORKDIR /torotrader-frontend

COPY package.json package-lock.json ./
RUN npm install

COPY . ./
RUN npm run ng build -- --configuration production --aot

# Stage 2: Serve with NGINX
FROM nginx:alpine

COPY ./.nginx/nginx.conf /etc/nginx/nginx.conf
RUN rm -rf /usr/share/nginx/html/*

COPY --from=builder /torotrader-frontend/dist/toro-trader-ui/browser /usr/share/nginx/html

# Evita erro se não existir nenhum arquivo (só em build inicial)
RUN chown -R nginx:nginx /usr/share/nginx/html || true

# Cria o env.js em tempo de build — isso só funciona se API_URL estiver definida no build
ARG API_URL=http://localhost:5550
RUN echo "window['env'] = { apiUrl: '${API_URL}' };" > /usr/share/nginx/html/env.js

EXPOSE 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]
