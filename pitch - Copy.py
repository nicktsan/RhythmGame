class MidiNotes():
	TUNING = 440
	NAMES = ['C', 'C#', 'D', 'D#', 'E', 'F',
			 'F#', 'G', 'G#', 'A', 'A#', 'B']

	def __init__(self):
		self._notes = {}
		self._real_freq = np.zeros(85)
		for i in range(24, 109):
			f = 2**((i-69)/12.0) * self.TUNING
			self._notes[self.NAMES[i % 12] + str(i/12-1)] = f
			self._real_freq[i-24] = f

	def freq(self, name):
		return self._notes[name]

	def find_nearest_freq(self):
		for f in range(len(pitch)):
			idx = (np.abs(self._real_freq-abs(pitch[f]))).argmin()
			pitch[f] = self._real_freq[idx]

#Question 4
#Returns a list of frequencies
def nums_to_midifreq(nums):
	TUNING = 440
	NAMES = ['C', 'C#', 'D', 'D#', 'E', 'F',
			 'F#', 'G', 'G#', 'A', 'A#', 'B']
	note_freqs = []
	m = MidiNotes()
	for n in nums:
		if n >= 12 and n <= 96:
			name = NAMES[n % 12] + str(n/12)
			note_freqs.append(m.freq(name))
	return note_freqs

def filter_notes(): #creates a list of frequencies, and corresponding times.
	filtered_notes = []
	filtered_time = []
	filtered_notes.append(pitch[0])
	filtered_time.append(time[0])
	for i in range(1, len(time)-1):
		if pitch[i] != filtered_notes[len(filtered_notes)-1]:
			filtered_notes.append(pitch[i])
			filtered_time.append(time[i])
	return filtered_notes, filtered_time


#csv_to_xlsx()
#xlsx_to_arrays("D:/Homework/CSC475/rhythm_game/AlexanderRoss_GoodbyeBolero_MIX_vamp_mtg-melodia_melodia_melody.csv.xlsx")
#plot_melodia()
A = MidiNotes()
A.find_nearest_freq()
new_freq, new_time = filter_notes()


