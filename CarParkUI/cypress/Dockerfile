FROM cypress/included:cypress-12.8.1-node-18.14.1-chrome-111.0.5563.64-1-ff-111.0-edge-111.0.1661.43-1

WORKDIR /app

COPY package.json .
COPY package-lock.json .

RUN npm install

COPY . .

ENTRYPOINT ["npx", "cypress", "run"]