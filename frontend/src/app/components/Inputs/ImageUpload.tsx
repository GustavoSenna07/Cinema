'use client';

interface ImageUploadProps {
  image: File | null;
  preview: string | null;
  onChange: (file: File | null, preview: string | null) => void;
}

export default function ImageUpload({
  image,
  preview,
  onChange
}: ImageUploadProps) {
  function handleImageChange(e: React.ChangeEvent<HTMLInputElement>) {
    const file = e.target.files?.[0];
    if (!file) return;

    const previewUrl = URL.createObjectURL(file);
    onChange(file, previewUrl);
  }

  function removeImage() {
    onChange(null, null);
  }

  return (
    <div className="flex flex-col gap-2 w-full max-w-md">
      <label className="text-[rgba(182,80,250,1)] font-semibold">
        Imagem
      </label>

      {!preview ? (
        <label className="cursor-pointer border-2 border-dashed border-purple-400 rounded-lg p-6 text-center hover:bg-purple-50 transition">
          <input
            type="file"
            accept="image/*"
            onChange={handleImageChange}
            className="hidden"
          />
          <p className="text-purple-600 font-medium">
            Clique para enviar uma imagem
          </p>
        </label>
      ) : (
        <div className="relative">
          <img
            src={preview}
            alt="Preview"
            className="rounded-lg w-full max-h-64 object-cover"
          />

          <button
            type="button"
            onClick={removeImage}
            className="absolute top-2 right-2 bg-red-500 text-white px-2 py-1 rounded-full hover:bg-red-600"
          >
            ✕
          </button>
        </div>
      )}
    </div>
  );
}
