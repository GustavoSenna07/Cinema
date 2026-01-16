import Input from "@/app/components/Inputs/Input"
import Button from "@/app/components/Inputs/Button"

export default function LoginPage() {
  return (
    <div className="bg-neutral-800 flex justify-center items-center p-2 box-border w-screen h-screen">
      <div className="bg-neutral-700 p-2 flex justify-center items-center w-full h-full rounded-2xl flex-col gap-2">
        <h1 className="text-5xl text-[rgba(182,80,250,1)] text-shadow-lg font-bold">Bem Vindo</h1>

        <Input type="email" label="Email" placeHolder="email.example@gmail.com"></Input>
        <Input type="cpf" label="CPF" placeHolder="XXX.XXX.XXX-XX"></Input>
        <Input type="password" label="Senha" placeHolder="Senha"></Input>

        <div className="flex justify-center items-center flex-col gap-3 pt-10">
          <Button variant="primary" href="" >Entrar</Button>
          <h1 className="text-[rgba(182,80,250,1)] text-2xl">Ainda Não tem uma Conta?</h1>
          <Button variant="primary" href="/cadastro">Cadastrar</Button>
        </div>
        
      </div>
    </div>
  )
}