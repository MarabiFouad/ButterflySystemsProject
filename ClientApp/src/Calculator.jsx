import React, { useState } from "react";
import "./Calculator.css";
import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Stack from "@mui/material/Stack";
import axios from "axios";
import Result from "./components/Result";
import Header from "./components/Header";
import LinearProgress from "@mui/material/LinearProgress";

const BaseUrl = `${process.env.REACT_APP_SERVER_URL}/api/v1/`;

function App() {
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const [number1, setNumber1] = useState(0);
  const [number2, setNumber2] = useState(0);
  const [isValidNumber1, setIsValidNumber1] = useState(false);
  const [isValidNumber2, setIsValidNumber2] = useState(false);
  const [showLoding, setShowLoding] = useState(false);

  const styles = {
    whiteSpace: "nowrap",
  };

  const CalculateResult = async (operator) => {
    setData(null);
    setError(null);

    !number1 ? setIsValidNumber1(false) : setIsValidNumber1(true);
    !number2 ? setIsValidNumber2(false) : setIsValidNumber2(true);

    if (!number1 || !number2) return;
    setShowLoding(true);
    await axios
      .get(
        `${BaseUrl}calculator/${operator}?number1=${number1}&number2=${number2}`
      )
      .then((response) => {
        setData(response.data);
      })
      .catch((error) => {
        console.log(error);
        setError(error);
      })
      .finally(() => {
        setShowLoding(false);
      });
  };

  return (
    <main className="calculator">
      <Header />
      <Box
        component="form"
        sx={{
          "& > :not(style)": { m: 1 },
        }}
        noValidate
        autoComplete="off"
      >
        <Stack
          direction={{ xs: "column", sm: "row" }}
          spacing={{ xs: 1, sm: 1, md: 1 }}
          justifyContent="space-between"
          alignItems="center"
        >
          <TextField
            error={!isValidNumber1}
            onChange={(e) => setNumber1(e.target.value)}
            id="outlined-basic"
            label="Enter a number"
            variant="outlined"
            fullWidth
            type="number"
          />
          <TextField
            error={!isValidNumber2}
            onChange={(e) => setNumber2(e.target.value)}
            id="outlined-basic"
            label="Enter a number"
            variant="outlined"
            type="number"
            fullWidth
          />
        </Stack>
        <Stack
          direction={{ xs: "column", sm: "row" }}
          spacing={{ xs: 1, sm: 1, md: 1 }}
          justifyContent="space-between"
          alignItems="center"
        >
          <Button
            type="button"
            variant="contained"
            onClick={() => CalculateResult("add")}
            fullWidth
          >
            Add (+)
          </Button>
          <Button
            type="button"
            variant="contained"
            onClick={() => CalculateResult("subtract")}
            style={styles}
            fullWidth
          >
            Subtract (-)
          </Button>
          <Button
            type="button"
            variant="contained"
            onClick={() => CalculateResult("multiply")}
            style={styles}
            fullWidth
          >
            Multiply (*)
          </Button>
          <Button
            type="button"
            variant="contained"
            onClick={() => CalculateResult("divide")}
            style={styles}
            fullWidth
          >
            Divide (/)
          </Button>
        </Stack>

        {showLoding ? (
          <Box sx={{ width: "100%" }}>
            <LinearProgress />
          </Box>
        ) : (
          <Result data={data} error={error} />
        )}
      </Box>
    </main>
  );
}

export default App;
