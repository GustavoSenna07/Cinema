import Input from "@/app/components/Input"
import Button from "@/app/components/Button"

export default function Cadastro() {
  return (
    <div className="bg-neutral-800 flex justify-center items-center p-2 box-border w-screen h-screen">
          <div className="bg-neutral-700 p-2 flex justify-center items-center w-full h-full rounded-2xl flex-col gap-2">
            <Input type="text" label="Nome" placeHolder="Nome de Usuario"></Input>  
            <Input type="Email" label="Email" placeHolder="email.exemplo@gmail.com"></Input>
            <Input type="cpf" label="CPF" placeHolder="XXX.XXX.XXX-XX"></Input>   
            <Input type="password" label="Senha" placeHolder="Senha"></Input>     

            <div className="pt-10">
              <Button variant="primary" href="/pages/start-page">Cadastrar</Button>  
            </div>

          </div>
        </div>
  )
}