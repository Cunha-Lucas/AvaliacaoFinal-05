"use client";

import { Box, Button, Container, Paper, Typography } from "@mui/material";
import router from "next/router";

function Menu() {
   function BotaoDespesas() {
    router.push("/lancamento/despesas/page");
  }

    function BotaoReceitas() {
    try {
        router.push("/lancamento/receitas/page");
      } catch {
        console.log("Erro ao avançar!");
      }
  }

  return (
    <Container maxWidth="sm">
      <Paper elevation={3} sx={{ padding: 4, mt: 8 }}>
        <Typography
          variant="h5"
          component="h1"
          textAlign={"center"}
          gutterBottom
        >
          Menu
        </Typography>
        <Box component="form" onSubmit={BotaoDespesas}>
          <Button
            type="submit"
            variant="outlined"
            color="info"
            fullWidth
            sx={{ mt: 2 }}
          >
            Despesas
          </Button>
        </Box>
        <Box component="form" onSubmit={BotaoReceitas}>
        <Button
            type="submit"
            variant="outlined"
            color="info"
            fullWidth
            sx={{ mt: 2 }}
          >
            Receitas
          </Button>
        </Box>
      </Paper>
    </Container>
  );
}

export default Menu;
