import "./ProgressBar.css";
export default function ProgressBar({ color, percentage }) {
  return (
    <div className="progressBar">
      <div
        className={`currStatus color${color}`}
        style={{ width: `${percentage}%`, background: `${color}` }}
      ></div>
    </div>
  );
}
