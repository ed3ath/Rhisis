QUEST_SCE_HARMONINDAILYBOOK2 = {
	title = 'IDS_PROPQUEST_SCENARIO_INC_000573',
	character = 'MaFl_SgRadion',
	end_character = 'MaFl_Gergantes',
	start_requirements = {
		min_level = 121,
		max_level = 129,
		job = { 'JOB_VAGRANT', 'JOB_MERCENARY', 'JOB_ACROBAT', 'JOB_ASSIST', 'JOB_MAGICIAN', 'JOB_KNIGHT', 'JOB_BLADE', 'JOB_JESTER', 'JOB_RANGER', 'JOB_RINGMASTER', 'JOB_BILLPOSTER', 'JOB_PSYCHIKEEPER', 'JOB_ELEMENTOR', 'JOB_KNIGHT_MASTER', 'JOB_BLADE_MASTER', 'JOB_JESTER_MASTER', 'JOB_RANGER_MASTER', 'JOB_RINGMASTER_MASTER', 'JOB_BILLPOSTER_MASTER', 'JOB_PSYCHIKEEPER_MASTER', 'JOB_ELEMENTOR_MASTER', 'JOB_KNIGHT_HERO', 'JOB_BLADE_HERO', 'JOB_JESTER_HERO', 'JOB_RANGER_HERO', 'JOB_RINGMASTER_HERO', 'JOB_BILLPOSTER_HERO', 'JOB_PSYCHIKEEPER_HERO', 'JOB_ELEMENTOR_HERO' },
		previous_quest = 'QUEST_SCE_HARMONINDAILYBOOK1',
	},
	rewards = {
		gold = 0,
	},
	end_conditions = {
	},
	dialogs = {
		begin = {
			'IDS_PROPQUEST_SCENARIO_INC_000574',
			'IDS_PROPQUEST_SCENARIO_INC_000575',
		},
		begin_yes = {
			'IDS_PROPQUEST_SCENARIO_INC_000576',
		},
		begin_no = {
			'IDS_PROPQUEST_SCENARIO_INC_000577',
		},
		completed = {
			'IDS_PROPQUEST_SCENARIO_INC_000578',
			'IDS_PROPQUEST_SCENARIO_INC_000579',
		},
		not_finished = {
			'IDS_PROPQUEST_SCENARIO_INC_000762',
		},
	}
}
