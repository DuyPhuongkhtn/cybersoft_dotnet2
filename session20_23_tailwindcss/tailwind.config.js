/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js}", "./node_modules/flowbite/**/*.js"],
  theme: {
    extend: {
      container: {
        center: true,
      },
      backgroundColor: {
        mainColor: "#A2D2DF",
        secondColor: "#F6EFBD",
        bodyColor: "#151937"
      },
      textColor: {
        mainColor: "#A2D2DF",
        secondColor: "#F6EFBD",
        profileColor: "#9334e9"
      },
      borderColor: {
        profileColor: "#9334e9"
      },
      backgroundImage: {
        'gradient-text': "linear-gradient(to left, #FC8E51, #FA61F9)"
      }
    },
  },
  plugins: [
    require('flowbite/plugin')
  ],
}

