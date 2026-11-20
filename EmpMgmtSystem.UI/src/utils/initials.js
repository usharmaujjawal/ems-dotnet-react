export default function getInitials(name) {
  const splitName = name.split(" ");
  return splitName.length >= 2
    ? splitName[0][0] + splitName[1][0]
    : splitName[0][0];
}
