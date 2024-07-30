  export let configurationRucula = {
    floatLabel: true,
    environments: [
      {
        env: "development",
        hostname: "http://localhost",
        port: "5270"
      },
      {
        env: "production",
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
    