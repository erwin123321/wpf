import { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

const kursy = [
  "Programowanie w C#",
  "Angular dla początkujących",
  "Kurs Django",
  "Tworzenie aplikacji w React",
  "Bazy danych SQL",
];

function App() {
  const [imieNazwisko, setImieNazwisko] = useState("");
  const [numerKursu, setNumerKursu] = useState("");

  
  const obsluzZapis = (event) => {
    event.preventDefault();

    console.log(imieNazwisko);

    const numer = Number(numerKursu);

    if (
      numerKursu.trim() !== "" &&
      Number.isInteger(numer) &&
      numer >= 1 &&
      numer <= kursy.length
    ) {
      console.log(kursy[numer - 1]);
    } else {
      console.log("Nieprawidłowy numer kursu");
    }
  };

  return (
    <div className="container mt-4">
      <h2>Liczba kursów: {kursy.length}</h2>

      <ol>
        {kursy.map((kurs, index) => (
          <li key={index}>{kurs}</li>
        ))}
      </ol>

      <form onSubmit={obsluzZapis}>
        <div className="mb-3">
          <label htmlFor="imieNazwisko" className="form-label">
            Imię i nazwisko
          </label>

          <input
            type="text"
            id="imieNazwisko"
            className="form-control"
            value={imieNazwisko}
            onChange={(event) =>
              setImieNazwisko(event.target.value)
            }
            required
          />
        </div>

        <div className="mb-3">
          <label htmlFor="numerKursu" className="form-label">
            Numer kursu
          </label>

          <input
            type="number"
            id="numerKursu"
            className="form-control"
            value={numerKursu}
            onChange={(event) =>
              setNumerKursu(event.target.value)
            }
            required
          />
        </div>

        <button type="submit" className="btn btn-primary">
          Zapisz do kursu
        </button>
      </form>
    </div>
  );
}

export default App;
