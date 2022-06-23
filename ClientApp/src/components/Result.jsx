import React from "react";
import Alert from "@mui/material/Alert";

export default function Result({ data, error }) {
  return (
    <div className="result">
      {data ? (
        <Alert severity="success">{data.clientDefaultDisplay}</Alert>
      ) : (
        ""
      )}
      {error?.response?.data ? (
        <Alert severity="error">{error?.response?.data.message}</Alert>
      ) : error?.message ? (
        <Alert severity="error">{error?.message}</Alert>
      ) : (
        ""
      )}
    </div>
  );
}
