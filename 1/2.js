const fs = require('fs');
const path = require('path');

const calculateFuel = mass => Math.floor(mass / 3) - 2;

const calculateFuelRequirements = (err, data) => {
	if (err) {
		console.log(err);
		throw err;
	}

	const input = data.toString().split('\n');

	const calculateFuelForFuel = mass => {
		if (mass <= 0) {
			return 0;
		}

		return mass + calculateFuelForFuel(calculateFuel(mass));
	};

	const fuelRequirement = input.reduce((totalFuel, currentMass) => {
		return (totalFuel += calculateFuelForFuel(calculateFuel(currentMass)));
	}, 0);

	console.log(fuelRequirement);
};

fs.readFile(path.resolve(__dirname, './data.txt'), calculateFuelRequirements);
