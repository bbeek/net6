module.exports = {
  content: ['./src/**/*.{html,ts}'],
  theme: {
    extend: {
      textColor : {
        'chique': 'rgb(141, 127, 91)',
      },
      height: {
				"10v": "10vh",
				"20v": "20vh",
				"30v": "30vh",
				"40v": "40vh",
				"50v": "50vh",
				"60v": "60vh",
				"70v": "70vh",
				"80v": "80vh",
				"90v": "90vh",
				"100v": "100vh",
			},
    },
  },
  darkMode: 'class', // or 'media' or 'class', By default this uses the prefers-color-scheme CSS media feature
  plugins: [require('@tailwindcss/forms'), require('@tailwindcss/typography')],
};
