const fs = require('fs');
const path = require('path');

const calculateFuelRequirements = (err, data) => {
	if (err) {
		console.log(err);
		throw err;
	}

	const input = data.toString().split('\n');

	const fuelRequirement = input.reduce((totalFuel, currentMass) => {
		return (totalFuel += Math.floor(currentMass / 3) - 2);
	}, 0);

	console.log(fuelRequirement);
};

fs.readFile(path.resolve(__dirname, './data.txt'), calculateFuelRequirements);
