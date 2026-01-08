'use client';

import { ChangeEvent, useEffect, useState } from 'react';

interface InputProps {
  label: string;
  placeHolder?: string;
  value?: unknown;
  type?: "text" | "email" | "password" | "date" | "duration" | "rating";
  required?: boolean;
  disabled?: boolean;
  error?: string;
  onChange?: (value: unknown) => void;
}

export default function Input({
  label,
  placeHolder,
  value,
  type,
  required = false,
  disabled = false,
  error,
  onChange,
}: InputProps) {
  const inputId = label.toLowerCase().replace(/\s/g, '-');

  const [hours, setHours] = useState(0);
  const [minutes, setMinutes] = useState(0);
  const [rating, setRating] = useState(0);

  useEffect(() => {
    if (type === 'duration') {
      onChange?.(hours * 60 + minutes);
    }
  }, [hours, minutes, type]);

  function renderField() {
    if (type === 'duration') {
      return (
        <div className="flex gap-4">
          <select
            aria-label="Horas"
            disabled={disabled}
            value={hours}
            onChange={(e) => setHours(Number(e.target.value))}
            className="bg-fuchsia-100 px-3 py-2 rounded-lg text-black"
          >
            {Array.from({ length: 24 }).map((_, i) => (
              <option key={i} value={i}>
                {i} h
              </option>
            ))}
          </select>

          <select
            aria-label="Minutos"
            disabled={disabled}
            value={minutes}
            onChange={(e) => setMinutes(Number(e.target.value))}
            className="bg-fuchsia-100 px-3 py-2 rounded-lg text-black"
          >
            {Array.from({ length: 60 }).map((_, i) => (
              <option key={i} value={i}>
                {i} min
              </option>
            ))}
          </select>
        </div>
      );
    }

    if (type === 'rating') {
      return (
        <select
          aria-label='Classificacao Indicativa'
          value={value}
          onChange={(e) => onChange?.(e.target.value)}
          className="bg-fuchsia-100 px-3 py-2 rounded-lg text-black"
          >
            <option value="">Selecione</option>
            <option value="L">Livre</option>
            <option value="10">10 Anos</option>
            <option value="12">12 Anos</option>
            <option value="14">14 Anos</option>
            <option value="16">16 Anos</option>
            <option value="18">18 Anos</option>
        </select>
      )
    }

    return (
      <input
        id={inputId}
        type={type}
        placeholder={placeHolder}
        value={value}
        required={required}
        disabled={disabled}
        onChange={(e) => onChange?.(e.target.value)
        }
        className="bg-fuchsia-100 px-3 py-2 rounded-lg text-black"
      />
    );
  }

  return (
    <div className="flex flex-col gap-1 w-full max-w-md">
      <label
        htmlFor={inputId}
        className="text-[rgba(182,80,250,1)] font-semibold"
      >
        {label}
      </label>

      {renderField()}

      {error && <span className="text-red-500 text-sm">{error}</span>}
    </div>
  );
}
