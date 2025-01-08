/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js}", "./node_modules/flowbite/**/*.js"],
  theme: {
    extend: {
      backgroundColor: {
        mainColor: "#A2D2DF",
        secondColor: "#F6EFBD",
        bodyColor: "#151937"
      },
      textColor: {
        mainColor: "#A2D2DF",
        secondColor: "#F6EFBD"
      }
    },
  },
  plugins: [
    require('flowbite/plugin')
  ],
}

