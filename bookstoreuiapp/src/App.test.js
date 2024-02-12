import { fireEvent, render, screen, act } from '@testing-library/react';
import '@testing-library/jest-dom';
import { renderWithProviders } from './test/utils/testUtils';

import App from './App';

test('App default page navigation', async() => {
  await act(async () => {
    renderWithProviders(<App />);
  });

  const homeTitle = await screen.findByText('Find Your Next Book');
  expect(homeTitle).toBeInTheDocument();

  fireEvent.click(screen.getByText('Books'))
  expect(await screen.findByText('Search Books')).toBeInTheDocument();

});