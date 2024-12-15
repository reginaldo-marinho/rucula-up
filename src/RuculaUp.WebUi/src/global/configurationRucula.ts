  export let configurationRucula = {
    floatLabel: true,
    environments: [
      {
        env: "staging",
        description:"Homologação",
        hostname: "http://localhost",
        port: "4900"
      },
      {
        env: "window",
        description:"Window",
        hostname: "http://localhost",
        port: "5100"
      },
      { 
        env: "development-ui",
        description:"Window",
        hostname: "https://localhost",
        port: "5001"
      },
      {
        env: "production",
        description:"Produção",
        hostname: "http://localhost",
        port: "5900"
      }
    ],
    localizations: [
      {
        locales: "pt-BR",
        language: "🇧🇷 Brasil",
        currency: "BRL",
        maxDecimal: 5
      }
    ]
  }  
    