"use client";

import {
  Toast,
  ToastClose,
  ToastDescription,
  ToastProvider,
  ToastTitle,
  ToastViewport,
} from "@/components/ui/toast";
import { useToast } from "@/components/ui/use-toast";

export function Toaster() {
  const { toasts } = useToast();

  return (
    <ToastProvider>
      {toasts.map(function ({ id, title, description, action, ...props }) {
        return (
          <Toast
            key={id}
            {...props}
            className="absolute bottom-4 right-4 gap-2 bg-red p-1.5 rounded-lg shadow-lg"
          >
            {title && <ToastTitle className="text-xs mb-2">{title}</ToastTitle>}
            {description && (
              <ToastDescription className="text-base">
                {description}
              </ToastDescription>
            )}

            {action}

            <ToastClose className="absolute bottom-8 right-1" />
          </Toast>
        );
      })}
      <ToastViewport />
    </ToastProvider>
  );
}
