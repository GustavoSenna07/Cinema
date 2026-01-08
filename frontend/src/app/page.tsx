"use client";

import Button from "./components/Inputs/Button";

export default function Home() {
  return (
    <div className="bg-[rgba(52,52,52,1)] w-screen h-screen justify-center items-center flex flex-col ">
      <div className="flex justify-center items-center mb-40">
        <h1 className="text-8xl text-[rgba(182,80,250,1)] text-shadow-lg font-bold">Cinema das Lendas</h1>
      </div>

      <div className="flex flex-col gap-10">
        <Button href="/pages/login-page" variant="primary">Entrar</Button>
        <Button href="/pages/cadastro" variant="primary">Criar Conta</Button>
      </div>
    </div>
  );
}
