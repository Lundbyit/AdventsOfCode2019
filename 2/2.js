const fs = require("fs");
const path = require("path");
let origin = fs
  .readFileSync(path.resolve(__dirname, "data.txt"))
  .toString()
  .split(",");

const intCodeProgram = (input, noun, verb) => {
  input[1] = noun;
  input[2] = verb;

  for (let i = 0; i < input.length; i += 4) {
    const opCode = input[i];
    const pos1 = input[i + 1];
    const pos2 = input[i + 2];
    const posToChange = input[i + 3];

    if (opCode == 99) {
      break;
    }

    if (opCode == 1) {
      input[posToChange] = parseInt(input[pos1]) + parseInt(input[pos2]);
      continue;
    }

    if (opCode == 2) {
      input[posToChange] = parseInt(input[pos1]) * parseInt(input[pos2]);
      continue;
    }
  }

  return input[0];
};

for (let noun = 0; noun < 99; noun++) {
  for (let verb = 0; verb < 99; verb++) {
    const output = intCodeProgram([...origin], noun, verb);
    if (output === 19690720) {
      console.log(`noun: ${noun}, verb: ${verb}, answer: ${100 * noun + verb}`);
      noun = verb = Number.MAX_VALUE;
    }
  }
}
