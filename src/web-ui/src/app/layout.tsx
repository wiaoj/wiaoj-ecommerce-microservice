import type { Metadata } from 'next';
import { Inter } from 'next/font/google';
import './globals.css';
import { Providers } from './providers';
import { Navbar } from '@nextui-org/react';

import 'react-toastify/dist/ReactToastify.css';
const inter = Inter({ subsets: ['latin'] });

export const metadata: Metadata = {
    title: 'wiaoj ecommerce',
    description: '-',
};

export default function RootLayout({
    children,
}: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <html lang="en">
            <body className={inter.className}>
                <Providers>
                    <main className="dark min-h-[200vh] bg-background text-foreground overflow-hidden">{children}</main>
                </Providers>
            </body>
        </html>
    );
}
