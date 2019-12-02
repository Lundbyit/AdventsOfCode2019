const fs = require("fs");
const path = require("path");
let input = fs
  .readFileSync(path.resolve(__dirname, "data.txt"))
  .toString()
  .split(",");

input[1] = 12;
input[2] = 2;

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

console.log(input[0]);
