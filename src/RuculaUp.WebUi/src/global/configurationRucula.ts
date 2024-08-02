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
    