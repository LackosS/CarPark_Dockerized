FROM cypress/base:16.16.0

WORKDIR /app

COPY package.json .
COPY package-lock.json .

RUN npm install

COPY . .

ENTRYPOINT ["npm", "run", "cypress:run"]