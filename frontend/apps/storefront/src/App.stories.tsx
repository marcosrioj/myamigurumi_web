import type { Meta, StoryObj } from '@storybook/react';
import App from './App';

const meta: Meta<typeof App> = {
  title: 'Pages/Storefront',
  component: App
};

export default meta;

export const Default: StoryObj<typeof App> = {
  render: () => <App />
};
