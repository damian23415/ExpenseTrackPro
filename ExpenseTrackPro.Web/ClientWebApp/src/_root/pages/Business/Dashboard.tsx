import { Chart as ChartJS, ArcElement, Tooltip, Legend } from "chart.js";
import { Doughnut } from "react-chartjs-2";

ChartJS.register(ArcElement, Tooltip, Legend);

const Dashboard = () => {
  const data = {
    datasets: [
      {
        label: "Suma",
        data: [300, 50],
        backgroundColor: ["#2EB432", "#FF1E0E"],
        hoverOffset: 4,
      },
    ],
  };

  return (
    <div className="flex w-full">
      <div className="general-element w-full">
        <p>
          <b>Podsumowanie</b>
        </p>
        <p>
          Bilans: <span>12398,432 zł</span>
        </p>
      </div>
      <div className="general-element flex">
        <p>Ten miesiąc</p>
        <div className="w-40">
          <Doughnut
            data={data}
            options={{
              responsive: true,
              maintainAspectRatio: true,
            }}
          />
        </div>
        <p>Tu tez jakas kwota</p>
      </div>
      <div className="general-element flex">
        <p>Ostatni miesiąc</p>
        <div className="w-40">
          <Doughnut
            data={data}
            options={{
              responsive: true,
              maintainAspectRatio: true,
            }}
          />
        </div>

        <p>2133,33 zł</p>
      </div>
    </div>
  );
};

export default Dashboard;
